import './App.css';
import React from 'react';
import MainMenu from './Components/MainMenu';
import Quiz from './Components/Quiz';
import EndScreen from './Components/EndScreen';
import { QuizProvider } from './Helpers/Contexts';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

function App() {
  return (
    <div className='App'>
      <BrowserRouter>
        <h1 className='gameName'>UNREACHED</h1>
        <h2 className='topic'>Questionnaire</h2>
        <QuizProvider>
          <Routes>
            <Route path ='/' element={<MainMenu />} />
            <Route path ='/quiz' element={<Quiz />} />
            <Route path='/results' element={<EndScreen />} />
          </Routes>
        </QuizProvider>
      </BrowserRouter>
    </div>
  );
}

export default App;
