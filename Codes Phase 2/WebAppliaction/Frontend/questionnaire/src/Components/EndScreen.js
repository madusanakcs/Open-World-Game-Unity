import React, { useContext } from 'react';
import { QuizContext } from '../Helpers/Contexts';
import '../App.css';

function EndScreen() {
    const { score, feedbackList, questions } = useContext(QuizContext);

    return (
        <div className='EndScreen'>
            <h1>Quiz Finished</h1>
            <h2>Your Score: {score}</h2>
            <div className='feedback-list'>
                {feedbackList.map((feedback, index) => {
                    const question = questions.find((q) => q.questionId === feedback.questionId);
                    const selectedAnswer = question.answerWrappers.find((a) => a.answerId === feedback.selectedAnswerId);
                    const specificFeedback = selectedAnswer ? feedback.specificFeedback : '';
                    const generalFeedback = feedback.generalFeedback;

                    return (
                        <div key={index} className='feedback-item'>
                            <h3>Question {feedback.questionId}</h3>
                            <p>{question.question}</p>
                            <ul>
                                {question.answerWrappers.map((answer, idx) => (
                                    <li key={idx}>
                                        <span className={answer.answerId === feedback.correctAnswerId ? 'correct-answer' : ''}>
                                            {String.fromCharCode(65 + idx)}. {answer.answerTitle}
                                            {answer.answerId === feedback.selectedAnswerId && (
                                                <p className='specific-feedback'>{specificFeedback}</p>
                                            )}
                                        </span>
                                    </li>
                                ))}
                            </ul>
                            <div className='feedback-icon'>📝</div>
                            <p className='general-feedback'>{generalFeedback}</p>
                        </div>
                    );
                })}
            </div>
            <button>Play Game</button>
        </div>
    );
}

export default EndScreen;
