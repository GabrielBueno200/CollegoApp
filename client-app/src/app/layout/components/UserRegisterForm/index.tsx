/* Modules | Functions */
import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { Formik, Form } from 'formik';

/* Models */
import { IUserRegister } from '../../../models/users/register';
import { IUser } from '../../../models/users/user';

/* Redux */
import { AppDispatch, AppState } from '../../../store';
import signUpAsync from '../../../store/reducers/user/actions/register/thunks';
import Input from './Input';
import Checkbox from './Checkbox';



interface IStateProps {
    registeredUser: IUser | {};
};

interface IDispatchProps {
    signUpAsync: (user: IUserRegister) => void;
};

type IProps = IStateProps & IDispatchProps;

const UserRegisterForm: React.FC<IProps> = ({registeredUser, signUpAsync}) => {

    const [user, setUser] = useState<IUserRegister>({
        userName: "",
        fullName: "",
        email: "",
        password: "",
        confirmPassword: "",
        courseId: "0f5c5c75-9c1c-4c68-918c-f619e40f1a50",
        university: "Centro Universitário FEI",
        termsAccepted: false
    });

    const handleSubmit = async (data:IUserRegister) => await signUpAsync(data);
    
    return(
        <Formik enableReinitialize initialValues={user} onSubmit={handleSubmit}>
            {({handleSubmit}) => 
                <Form style={{display: 'flex', flexDirection: 'column'}} onSubmit={handleSubmit}>
                    <Input placeholder="Digite o seu username..." type="text" name="userName" label="Nome:"/>
                    <Input placeholder="Digite o seu nome completo.." type="text" name="fullName" label="Nome completo:"/>
                    <Input placeholder="Digite o seu endereço de e-mail..." type="email" name="email" label="Email:"/>
                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha:"/>
                    <Input placeholder="Confirme a sua senha..." type="password" name="confirmPassword" label="Confirmação de senha"/>
                    
                    {/*Alterar depois*/}
                    <Input type="text" name="courseId" label="Curso:"/>
                    <Input type="text" name="university" label="Universidade"/>
                    {/* - */}

                    <Checkbox label="Aceito os termos" name="termsAccepted"/>

                    <button type="submit">Enviar</button>

                </Form>}
        </Formik>
    )
}

const mapStateToProps = (state:AppState): IStateProps => ({
    registeredUser: state.users
});

const mapDispatchToProps = (dispatch:AppDispatch): IDispatchProps => ({
    signUpAsync: (user:IUserRegister) => dispatch(signUpAsync(user))
});

export default connect(mapStateToProps, mapDispatchToProps)(UserRegisterForm);

