import { createContext, useState } from "react";

export const QuizContext = createContext();

export const QuizProvider = ({ children }) => {
    const [token, setToken] = useState("");
    const [questions, setQuestions] = useState([]);
    const [score, setScore] = useState(null);
    const [feedbackList, setFeedbackList] = useState([]);

    return (
        <QuizContext.Provider value={{ token, setToken, questions, setQuestions, score, setScore, feedbackList, setFeedbackList }}>
            {children}
        </QuizContext.Provider>
    );
};
