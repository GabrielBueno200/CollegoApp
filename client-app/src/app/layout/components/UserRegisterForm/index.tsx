/* Modules | Functions */
import React, { useState, useCallback } from 'react';
import { connect } from 'react-redux';
import { Formik } from 'formik';

/* Styles */
import './styles.scss';

/* Models */
import { EmptyUserRegisterObject, IUserRegister } from '../../../models/users/register';
import { IUser } from '../../../models/users/user';

/* Redux */
import { AppDispatch, AppState } from '../../../store';
import signUpAsync from '../../../store/reducers/user/actions/register/thunks';

/* Components */
import Input from '../../../common/Input';
import Checkbox from '../../../common/Checkbox';
import Button from '../../../common/Buttons/Default';
import Form from '../../../common/Form';
import schema from './validation';
import Select from '../../../common/Select';

/* Props */
interface IStateProps {
    registeredUser: IUser | {};
};

interface IDispatchProps {
    signUpAsync: (user: IUserRegister) => Promise<void>;
};

type IProps = IStateProps & IDispatchProps;


const UserRegisterForm: React.FC<IProps> = ({registeredUser, signUpAsync}) => {

    const [user] = useState<IUserRegister>({...EmptyUserRegisterObject});

    const handleSubmit = useCallback(async (data:IUserRegister) => await signUpAsync(data), [registeredUser]);
    
    return(

        <Formik enableReinitialize initialValues={user} onSubmit={handleSubmit} validationSchema={schema}>
            
            <Form className="user-register-form">

                <Input placeholder="Digite o seu username..." type="text" name="userName" label="Nome:"/>
                <Input placeholder="Digite o seu nome completo.." type="text" name="fullName" label="Nome completo:"/>
                <Input placeholder="Digite o seu endereço de e-mail..." type="email" name="email" label="Email:"/>
                
                <div className="passwords">
                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha:"/>
                    <Input placeholder="Confirme a sua senha..." type="password" 
                        name="confirmPassword" label="Confirmação de senha" />
                </div>

                <div className="academics">
                    <Select name="courseId" label="Curso" placeholder="Selecione o seu curso"/>
                    <Select name="university" label="Universidade" placeholder="Selecione a sua universidade"/>
                </div>

                <Checkbox label="Aceito os termos" name="termsAccepted"/>

                <Button type="submit">Enviar</Button>

            </Form>

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