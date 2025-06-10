import React from 'react';
import { Provider } from 'react-redux';
import { store } from './store/store';
import Sidebar from './components/Sidebar/Sidebar';
import './App.scss';

const App: React.FC = () => {
  return (
    <Provider store={store}>
      <div className="app">
        <Sidebar />
        <main className="main-content">
          <h1>Welcome to Maggie's Playground</h1>
          <p>Your new application is ready to be built!</p>
        </main>
      </div>
    </Provider>
  );
};

export default App;
