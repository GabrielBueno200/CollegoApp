import React from 'react';
import { IUserRegister } from '../models/users/register';

const user:IUserRegister = {
    userName: "testeeee",
    fullName: "teste teste",
    email: "testee@collego.com",
    password: "pa$$worD",
    confirmPassword: "pa$$word",
    courseId: "0f5c5c75-9c1c-4c68-918c-f619e40f1a50",
    university: "FEI",
    termsAccepted: true
}

const test: React.FC = () => {


    return (
        <div>

            <button onClick={() => {}}>OK</button>
            
        </div>
    );
}

export default test;