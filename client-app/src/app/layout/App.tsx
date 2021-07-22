import React from 'react';
import { Provider } from 'react-redux';
import store from '../store';
import Test from "./test";

const App: React.FC = () =>

    <Provider store={store}>
        <div className="App">
            <Test/>
        </div>
    </Provider>


export default App;

