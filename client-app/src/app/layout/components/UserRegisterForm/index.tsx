/* Modules | Functions */
import React, { useState, useCallback } from 'react';
import { connect } from 'react-redux';
import { Formik } from 'formik';
import { mapUniversitiesToSelect } from '../../../services/university/map';
import schema from './validation';

/* Styles */
import './styles.scss';

/* Models */
import { EmptyUserRegisterObject, IUserRegister } from '../../../models/users/register';
import { IUser } from '../../../models/users/user';
import { IUniversity } from '../../../models/universities/university';

/* Redux */
import { AppDispatch, AppState } from '../../../store';
import signUpAsync from '../../../store/reducers/user/actions/register/thunks';
import findByAcronymAsync from '../../../store/reducers/universities/actions/findByAcronym/thunks';

/* Components */
import Input from '../../../common/Input';
import Checkbox from '../../../common/Checkbox';
import Button from '../../../common/Buttons/Default';
import Form from '../../../common/Form';
import Select from '../../../common/Select';
import UniversitySelect from '../../../common/Select/UniversitySelect';

/* Props */
interface IStateProps {
    registeredUser: IUser | {};
    universities: IUniversity[] | [];
};

interface IDispatchProps {
    signUpAsync: (user: IUserRegister) => Promise<void>;
    findUniversitiesByAcronym: (acronym: string) => Promise<void>;
};

type IProps = IStateProps & IDispatchProps;


const UserRegisterForm: React.FC<IProps> = ({registeredUser, signUpAsync, universities, findUniversitiesByAcronym}) => {

    const [user] = useState<IUserRegister>({...EmptyUserRegisterObject});

    const handleSubmit = useCallback(async (data:IUserRegister) => await signUpAsync(data), [registeredUser]);
    
    const loadUniversities = useCallback(async (acronym: string) => await findUniversitiesByAcronym(acronym), [universities]);

    return(

        <Formik enableReinitialize initialValues={user} onSubmit={handleSubmit} validationSchema={schema}>
            
            <Form className="user-register-form">

                <Input placeholder="Digite o seu username..." type="text" name="userName" label="Nome de usuário:"/>
                <Input placeholder="Digite o seu nome completo.." type="text" name="fullName" label="Nome completo:"/>
                <Input placeholder="Digite o seu endereço de e-mail..." type="email" name="email" label="Email:"/>
                
                <div className="passwords">
                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha:"/>
                    <Input placeholder="Confirme a sua senha..." type="password" 
                        name="confirmPassword" label="Confirmação de senha" />
                </div>

                <div className="academics">
                    <Select name="courseId" label="Curso" placeholder="Selecione o seu curso"/>
                    <UniversitySelect 
                        asyncFunction={ loadUniversities }
                        data = { universities }
                        mapDataToSelect = { mapUniversitiesToSelect }
                        name="university"  
                        label="Universidade" 
                        placeholder="Pesquise pela sua universidade (por sigla)"/>
                </div>

                <Checkbox label="Li e aceito os termos de condições de uso" name="termsAccepted"/>

                <Button className="submit-button" type="submit">Enviar</Button>

            </Form>

        </Formik>
        
    )
}

const mapStateToProps = (state:AppState): IStateProps => ({
    registeredUser: state.users.data,
    universities: state.universities.data
});

const mapDispatchToProps = (dispatch:AppDispatch): IDispatchProps => ({
    signUpAsync: (user:IUserRegister) => dispatch(signUpAsync(user)),
    findUniversitiesByAcronym: (acronym: string) => dispatch(findByAcronymAsync(acronym))
});

export default connect(mapStateToProps, mapDispatchToProps)(UserRegisterForm);