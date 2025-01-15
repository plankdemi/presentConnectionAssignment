import axios from "axios";
import React, {useEffect,useState } from "react";
function Scores() {

    const [testeeData, setTesteeData] = useState(null);


    useEffect(() => {
        axios
            .get("https://localhost:52582/api/Testee")
            .then((response) => {
                setTesteeData(response.data);
            })
            .catch((error) => {
                console.error("Error fetching data", error);
            });
    }, []);

    console.log(testeeData);

    return (
        <div className="h-screen bg-zinc-900 flex justify-center items-center p-8">

            <div className="w-1/2 justify-center m-8 bg-emerald-700 text-white text-center p-6 rounded text-white text-2xl ">

                <table className="table-auto w-full ">
                    <thead>
                        <tr>
                            <th>Spot</th>
                            <th>User</th>
                            <th>Scored</th>
                            <th>Test completed at</th>
                        </tr>
                    </thead>
                    <tbody>


                        {testeeData && testeeData.length > 0 ? (
                            testeeData.map((testee, index) => {

                                switch (index) {
                                    case 0:

                                        return (<tr className="text-center">
                                            <td className="px-8 py-4 bg-yellow-300 text-black" >{index + 1}</td>
                                            <td className="px-8 py-4 bg-yellow-300 text-black" >{testee.email}</td>
                                            <td className="px-8 py-4 bg-yellow-300 text-black">{testee.score}</td>
                                            <td className="px-8 py-4 bg-yellow-300 text-black"> {new Date(testee.date).toLocaleDateString('en-GB')}</td>

                                        </tr>);

                                    case 1:
                                        return (<tr className="text-center">
                                            <td className="px-8 py-4 bg-zinc-100 text-black" >{index + 1}</td>
                                            <td className="px-8 py-4 bg-zinc-100 text-black" >{testee.email}</td>
                                            <td className="px-8 py-4 bg-zinc-100 text-black">{testee.score}</td>
                                            <td className="px-8 py-4 bg-zinc-100 text-black"> {new Date(testee.date).toLocaleDateString('en-GB')}</td>

                                        </tr>);
                                    case 2:
                                        return (<tr className="text-center">
                                            <td className="px-8 py-4 bg-yellow-900 text-black" >{index + 1}</td>
                                            <td className="px-8 py-4 bg-yellow-900 text-black" >{testee.email}</td>
                                            <td className="px-8 py-4 bg-yellow-900 text-black">{testee.score}</td>
                                            <td className="px-8 py-4 bg-yellow-900 text-black"> {new Date(testee.date).toLocaleDateString('en-GB')}</td>

                                        </tr>);
                                    default:
                                        return (
                                            <tr className="text-center">
                                                <td className={`px-8 py-4`} >{index + 1}</td>
                                                <td className={`px-8 py-4`} >{testee.email}</td>
                                                <td className={`px-8 py-4`}>{testee.score}</td>
                                                <td className={`px-8 py-4`}> {new Date(testee.date).toLocaleDateString('en-GB')}</td>

                                            </tr>
                                        );

                                }

                            })
                        ) : (
                            <tr>
                                <td className="text-center">No Testee available</td>
                            </tr>
                        )}



                    </tbody>
                </table>
            </div>

        </div>
    )

}

export default Scores;