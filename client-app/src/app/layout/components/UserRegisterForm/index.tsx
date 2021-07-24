/* Modules | Functions */
import React, { useState, useEffect } from 'react';
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
import Input from '../../../common/Input';
import Checkbox from '../../../common/Checkbox';
import Button from '../../../common/Buttons/Default';
import Form from '../../../common/Form';

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

    const handleSubmit = async (data:IUserRegister) => await signUpAsync(data);
    
    return(

        <Formik enableReinitialize initialValues={user} onSubmit={handleSubmit}>
            <Form className="user-register-form">
                <Input placeholder="Digite o seu username..." type="text" name="userName" label="Nome:"/>
                <Input placeholder="Digite o seu nome completo.." type="text" name="fullName" label="Nome completo:"/>
                <Input placeholder="Digite o seu endereço de e-mail..." type="email" name="email" label="Email:"/>
                
                <div className="passwords">
                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha:"/>
                    <Input placeholder="Confirme a sua senha..." type="password" 
                        name="confirmPassword" label="Confirmação de senha" />
                </div>

                {/*Alterar depois*/}
                <Input type="text" name="courseId" label="Curso:"/>
                <Input type="text" name="university" label="Universidade"/>
                {/* - */}

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

