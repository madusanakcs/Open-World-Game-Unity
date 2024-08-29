import React, { useState, useContext } from 'react';
import { QuizContext } from '../Helpers/Contexts';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

function Quiz() {
    const { token, questions, setScore, setFeedbackList } = useContext(QuizContext);
    const [currQuestion, setCurrQuestion] = useState(0);
    const [answers, setAnswers] = useState({});
    const [selectedAnswer, setSelectedAnswer] = useState(null);
    const navigate = useNavigate();

    // Function to handle answer selection
    const handleAnswerClick = (answerId) => {
        setAnswers({ ...answers, [questions[currQuestion].questionId]: answerId });
        if (answerId !== selectedAnswer) {
            setSelectedAnswer(answerId);
        }
    };

    // Function to navigate to the next question
    const nextQuestion = () => {
        setCurrQuestion(currQuestion + 1);
        const nextAnswer = answers[questions[currQuestion + 1].questionId];
        setSelectedAnswer(nextAnswer !== undefined ? nextAnswer : null);
    };
    
    // Function to navigate to the previous question
    const prevQuestion = () => {
        const prevQuestionIndex = currQuestion - 1;
        setCurrQuestion(prevQuestionIndex);
        const prevAnswer = answers[questions[prevQuestionIndex].questionId];
        setSelectedAnswer(prevAnswer !== undefined ? prevAnswer : null);
    };

    // Function to handle quiz submission
    const handleSubmit = async () => {
        const answeredQuestions = Object.keys(answers);
        if (answeredQuestions.length < questions.length) {
            alert('Please answer all questions before submitting.');
        } else {
            const data = answeredQuestions.map(questionId => ({
                questionId: parseInt(questionId),
                answerId: answers[questionId]
            }));
            try {
                const response = await axios.post('http://localhost:8080/quiz/submit', data, {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });
                const { score, feedbackList } = response.data;
                setScore(score);
                setFeedbackList(feedbackList);
                navigate('/results');
            } catch (error) {
                console.error('Error submitting quiz:', error);
                alert('You already done the quiz.');
            }
        }
    };

    return (
        <div className='Quiz'>
            <h1>Question {currQuestion + 1}</h1>
            <h1>{questions[currQuestion].question}</h1>
            <div className='answers'>
                {questions[currQuestion].answerWrappers.map((answer, index) => (
                    <button
                        key={answer.answerId}
                        onClick={() => handleAnswerClick(answer.answerId)}
                        className={answer.answerId === selectedAnswer ? 'selected' : ''}
                    >
                        {String.fromCharCode(65 + index)}. {answer.answerTitle}
                    </button>
                ))}
            </div>

            <div className='options'>
                {currQuestion === 0 && (
                    <p></p>
                )}
                {currQuestion > 0 && (
                    <button onClick={prevQuestion}>Previous</button>
                )}
                {currQuestion < questions.length - 1 && (
                    <button onClick={nextQuestion}>Next</button>
                )}
                {currQuestion === questions.length - 1 && (
                    <button onClick={handleSubmit}>Submit</button>
                )}
            </div>
        </div>
    );
}

export default Quiz;
