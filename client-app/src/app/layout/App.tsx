import React from 'react';
import { Provider } from 'react-redux';
import store from '../store';

const App: React.FC = () =>
    <Provider store={store}>
        <div className="App">
        </div>
    </Provider>


export default App;
