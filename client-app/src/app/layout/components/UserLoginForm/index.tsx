/* Modules | Functions */
import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { Formik } from 'formik';

/* Styles */
//import './styles.scss';

/* Models */
import { EmptyUserLoginObject, IUserLogin } from '../../../models/users/login';
import { IUser } from '../../../models/users/user';
import { ISuccess } from '../../../store/reducers/models/success';

/* Redux */
import { AppDispatch, AppState } from '../../../store';
import signInAsync from '../../../store/reducers/user/actions/login/thunks';

/* Components */
import Input from '../../../common/Input';
import Button from '../../../common/Buttons/Default';
import Form from '../../../common/Form';

/* Hooks */
import useWarnings from '../../../hooks/useWarnings';

/* Utils */
import schema from './validation';

/* Props */
interface IStateProps {
    loggedUser: IUser | {};
    success?: ISuccess;
    errors: any;
};

interface IDispatchProps {
    signInAsync: (user: IUserLogin) => Promise<void>;
};

type IProps = IStateProps & IDispatchProps;


const UserRegisterForm: React.FC<IProps> = ({   
    signInAsync,
    errors
}) => {

    const [ user ] = useState<IUserLogin>({...EmptyUserLoginObject});

    const [ hasWarnings, showWarnings, Warnings ] = useWarnings([ errors, !!errors, false ]);

    const handleSubmit = async (data:IUserLogin) => { 
        
        await signInAsync(data);

        showWarnings();

    };
    
    return(
        <>
            {hasWarnings && <Warnings/>}

            <Formik enableReinitialize initialValues={ user } onSubmit={ handleSubmit } validationSchema={ schema }>
                
                <Form className="user-register-form">

                    <Input placeholder="Digite o seu nome de usuário..." type="text" name="userName" label="Nome de usuário"/>

                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha"/>
                        
                    <Button className="submit-button" type="submit">Enviar</Button>
                
                </Form>
                
            </Formik>
        </>
    )
}

const mapStateToProps = (state:AppState): IStateProps => ({
    loggedUser: state.users.data,
    errors: state.users.error,
    success: state.users.successMessage,
});

const mapDispatchToProps = (dispatch:AppDispatch): IDispatchProps => ({
    signInAsync: (user:IUserLogin) => dispatch(signInAsync(user))
});

export default connect(mapStateToProps, mapDispatchToProps)(UserRegisterForm);