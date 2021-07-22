import React from 'react';
import { Provider } from 'react-redux';
import store from '../store';
import UserRegisterForm from './components/UserRegisterForm';


const App: React.FC = () =>

    <Provider store={store}>
        <div className="App">
            <UserRegisterForm/>
        </div>
    </Provider>


export default App;

