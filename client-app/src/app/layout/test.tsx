import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { Provider } from 'react-redux';
import { IUserRegister } from '../models/users/register';
import { IUser } from '../models/users/user';
import { AppDispatch, AppState } from '../store';
import signUpAsync from '../store/reducers/user/actions/register/thunks';

const userr:IUserRegister = {
    userName: "testeeee",
    fullName: "teste teste",
    email: "testee@collego.com",
    password: "pa$$worD",
    confirmPassword: "pa$$worD",
    courseId: "0f5c5c75-9c1c-4c68-918c-f619e40f1a50",
    university: "FEI",
    termsAccepted: true
}


interface IStateProps {
    user: IUser | {};
};

interface IDispatchProps {
    signUpAsync: (user: IUserRegister) => void;
};

type IProps = IStateProps & IDispatchProps;

const Test: React.FC<IProps> = ({user, signUpAsync}) => {
    
    useEffect(() => {
         ( async () => await signUpAsync(userr) )();
    }, []);
    
    return(
        <div className="yrdy">

            
        </div>
    )
}

const mapStateToProps = (state:AppState): IStateProps => ({
    user: state.users
});

const mapDispatchToProps = (dispatch:AppDispatch): IDispatchProps => ({
    signUpAsync: (user:IUserRegister) => dispatch(signUpAsync(user))
});

export default connect(mapStateToProps, mapDispatchToProps)(Test);

