import React from 'react';
import { Provider } from 'react-redux';
import store from '../store';
import Home from './pages/Home';
import './styles.scss';

const App: React.FC = () =>

    <Provider store={store}>
        <Home/>
    </Provider>


export default App;

