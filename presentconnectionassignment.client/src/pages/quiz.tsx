import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Quiz() {
    const [quizData, setQuizData] = useState(null);
    const [formData, setFormData] = useState({});
    const [testStatus, setTestStatus] = useState(false);
    const [email, setEmail] = useState("");
    const [displayErrorMessage, setDisplayErrorMessage] = useState(false);
    const [currentQuestion, setCurrentQuestion] = useState(0);
    const [numberOfQuestions, setNumberOfQuestions] = useState(0);
    const [userEmail, setUserEmail] = useState("");
    const navigate = useNavigate(); 


  

    useEffect(() => {
        axios
            .get("https://localhost:52582/api/Quiz")
            .then((response) => {
                setQuizData(response.data);
            })
            .catch((error) => {
                console.error("Error fetching data", error);
            });
    }, []);

    const handleChange = (event, questionId) => {
        const { type, value, checked } = event.target;

        setFormData((prev) => {
            if (type === "checkbox") {
                const selectedOptions = prev[questionId] || [];
                return {
                    ...prev,
                    [questionId]: checked
                        ? [...selectedOptions, value] 
                        : selectedOptions.filter((option) => option !== value) 
                };
            }
            else if (type === "radio") {
                return {
                    ...prev,
                    [questionId]: [value],
                };
            }
            return {
                ...prev,
                [questionId]: [value], 
            };
        });
    };


    const isEmailValid = (email) => {
        
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    };

    const handleStartQuiz = () => {
        if (isEmailValid(email)) {
            setTestStatus(true);
            setUserEmail(email);
        } else {
            handleEmailError();
        }
    };

    const handleEmailError = () => {
        setDisplayErrorMessage(true);
    };

    const handleNextQuestion = (event) => {
        event.preventDefault();
        setCurrentQuestion(currentQuestion + 1);

    };

    const handlePreviousQuestion = (event) => {
        event.preventDefault();
        setCurrentQuestion(currentQuestion - 1);

    };

    const handleFormSubmit = async (event) => {
        event.preventDefault();

        try {

            const response = await axios.post("https://localhost:52582/api/Grading", {
                UserEmail: userEmail, 
                FormData: formData,   
            });

            console.log("Form submitted successfully:", response.data);
            navigate("/scores");
        } catch (error) {
            console.error("Error submitting form:", error);
            alert("There was an error submitting the form.");
        }
    };

 
    return (
        <div className="h-screen bg-zinc-900 flex justify-center items-center">
            <div className={`bg-emerald-700 text-center p-6 rounded ${!testStatus ? "" : "hidden"}`}>
                <h1 className="text-white text-2xl font-bold mb-4">Welcome to the quiz</h1>
                <div className="dark:bg-gray-800 w-full flex justify-center items-center">
                    <div className="max-w-xl mx-auto p-6">
                        <div className="flex items-center mt-1">
                            <input
                                type="email"
                                id="input-9"
                                className="w-full h-10 px-3 text-sm text-gray-700 border border-r-0 rounded-r-none border-blue-500 focus:outline-none rounded shadow-sm"
                                placeholder="user@mail.com"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                            />
                            <button
                                className="h-10 min-w-max px-6 text-sm bg-blue-500 border border-l-0 border-blue-500 rounded-r shadow-sm text-blue-50 hover:text-white hover:bg-blue-400 hover:border-blue-400 focus:outline-none"
                                onClick={handleStartQuiz}
                                
                            >
                                Start the quiz
                            </button>
                           
                        </div>
                        <p className={`${displayErrorMessage ? "vissible" : "invisible"} font-bold text-rose-500 pt-8 `}>Email is invalid</p>
                    </div>
                </div>
            </div>

            <form className={`w-1/2 bg-emerald-700 text-center p-6 rounded text-white text-2xl ${testStatus ? "" : "hidden"}` }>
                {quizData && quizData.length > 0 ? (
                    quizData.map((question, index) => {

                        if (index > numberOfQuestions) setNumberOfQuestions(index);

                        const isHidden = index !== currentQuestion;

                        switch (question.questionType) {
                            case "TextBox":
                                return (
                                    <div key={question.questionId} className={`p-8 m-4 questionIndex-${index} ${isHidden ? "hidden" : ""}`}>
                                        <label className="block text-left">{question.question}</label>
                                        <input
                                        className="w-full bg-slate-700 rounded"
                                            type="text"
                                            name={`question-${question.questionId}`}
                                            value={formData[question.questionId] || ""} 
                                            onChange={(e) => handleChange(e, question.questionId)}
                                        />
                                    </div>
                                );

                            case "CheckBox":
                                return (
                                    <div key={question.questionId} className={`p-8 m-4 questionIndex-${index} ${isHidden ? "hidden" : ""}`} >
                                        <label>{question.question}</label>
                                        <div>
                                            {question.possibleQuestionAnswers.map((option, index) => (
                                                <label key={index} className="block text-left">
                                                    <input
                                                        
                                                        type="checkbox"
                                                        name={`question-${question.questionId}`}
                                                        value={option}
                                                        checked={formData[question.questionId]?.includes(option) || false}
                                                        onChange={(e) => handleChange(e, question.questionId)}
                                                    />
                                                    {option}
                                                </label>
                                            ))}
                                        </div>
                                    </div>
                                );

                            case "RadioBtn":

                                return (
                                    <div key={question.questionId} className={`p-8 m-4 questionIndex-${index} ${isHidden ? "hidden" : ""}`}>
                                        <label >{question.question}</label>
                                        <div>
                                            {question.possibleQuestionAnswers.map((option, index) => (
                                                <label className="block text-left" key={index}>
                                                    <input
                                                        
                                                        type="radio"
                                                        name={`question-${question.questionId}`}
                                                        value={option}
                                                        checked={formData[question.questionId] && formData[question.questionId].includes(option)}
                                                        onChange={(e) => handleChange(e, question.questionId)}
                                                    />
                                                    {option}
                                                </label>
                                            ))}
                                        </div>
                                    </div>
                                );

                            default:
                                return null;
                        }
                    })
                ) : (
                    <p>No questions available</p>
                )}

                <div className="p-8 m-2">

                    <button
                        type="button"
                        className={`h-10 min-w-max px-6 mx-1 text-sm bg-blue-500 border border-l-0 border-blue-500 rounded-r shadow-sm text-blue-50 hover:text-white hover:bg-blue-400 hover:border-blue-400 focus:outline-none ${currentQuestion!==0 ? "" :"hidden"}`}
                        onClick={handlePreviousQuestion}

                    >
                        Previous
                    </button>



                    <button
                        type="button"
                        className={`h-10 min-w-max px-6 mx-1 text-sm bg-blue-500 border border-l-0 border-blue-500 rounded-r shadow-sm text-blue-50 hover:text-white hover:bg-blue-400 hover:border-blue-400 focus:outline-none ${currentQuestion !== numberOfQuestions ? "" : "hidden"}`}
                        onClick={handleNextQuestion}

                    >
                        Next
                    </button>

                    <button
                        type="button"
                        className={`h-10 min-w-max px-6 mx-1 text-sm bg-blue-500 border border-l-0 border-blue-500 rounded-r shadow-sm text-blue-50 hover:text-white hover:bg-blue-400 hover:border-blue-400 focus:outline-none ${currentQuestion === numberOfQuestions ? "" : "hidden"}`}
                        onClick={handleFormSubmit}
                    >
                        Finish
                    </button>

                </div>
   
            </form>
        </div>
    );
}

export default Quiz;