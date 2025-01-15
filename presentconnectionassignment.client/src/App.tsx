import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Routes, useNavigate } from 'react-router-dom';
import Quiz from './pages/quiz'; 
import Scores from "./pages/scores";

function App() {
    const navigate = useNavigate();
    const [redirect, setRedirect] = useState(true);

    useEffect(() => {
       
        if (redirect) {
            setRedirect(false);
            navigate('/quiz');
        }
        
    }, [navigate]);

    return (
        <Routes>
            <Route path="/quiz" element={<Quiz />} />
            <Route path="/scores" element={<Scores/>} />
        </Routes>
    );
}

function RootApp() {
    return (
        <Router>
            <App />
        </Router>
    );
}

export default RootApp;