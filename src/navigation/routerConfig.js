import React from 'react';
import { Routes, Route, BrowserRouter, Link } from 'react-router-dom';
import { HomePage } from '../views/HomePage/HomePage';
import { SamplePage } from '../views/SamplePage/SamplePage';

export const RouterConfig = () => {
  return (
    <BrowserRouter>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/sample">Books</Link>
          </li>
        </ul>
      </nav>

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/sample" element={<SamplePage />} />
      </Routes>
    </BrowserRouter>
  );
};

export default RouterConfig;
