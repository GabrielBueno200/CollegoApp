/* Modules | Functions */
import React, { useState, useEffect, useCallback } from 'react';
import { connect } from 'react-redux';
import { Formik } from 'formik';
import { mapUniversitiesToSelect } from '../../../services/university/map';

/* Styles */
import './styles.scss';

/* Models */
import { EmptyUserRegisterObject, IUserRegister } from '../../../models/users/register';
import { IUser } from '../../../models/users/user';
import { ICourse } from '../../../models/courses/course';
import { IUniversity } from '../../../models/universities/university';

/* Redux */
import { AppDispatch, AppState } from '../../../store';
import signUpAsync from '../../../store/reducers/user/actions/register/thunks';
import findByAcronymAsync from '../../../store/reducers/universities/actions/findByAcronym/thunks';
import findCoursesAsync from '../../../store/reducers/courses/actions/load/thunks';

/* Components */
import Input from '../../../common/Input';
import Checkbox from '../../../common/Checkbox';
import Button from '../../../common/Buttons/Default';
import Form from '../../../common/Form';
import Select from '../../../common/Select';
import AsyncSelect from '../../../common/Select/AsyncSelect';

/* Utils */
import schema, { usernameMask } from './validation';
import { mapCoursesToSelect } from '../../../services/course/map';
import MaskedInput from '../../../common/Input/MaskedInput';

/* Props */
interface IStateProps {
    registeredUser: IUser | {};
    universities: IUniversity[] | [];
    courses: ICourse[] | [];
};

interface IDispatchProps {
    signUpAsync: (user: IUserRegister) => Promise<void>;
    findUniversitiesByAcronym: (acronym: string) => Promise<void>;
    findCoursesAsync: () => Promise<void>;
};

type IProps = IStateProps & IDispatchProps;


const UserRegisterForm: React.FC<IProps> = ({   
    courses, 
    registeredUser, 
    universities, 
    signUpAsync,
    findCoursesAsync,
    findUniversitiesByAcronym
}) => {

    const [ user ] = useState<IUserRegister>({...EmptyUserRegisterObject});

    const handleSubmit = useCallback(async (data:IUserRegister) => await signUpAsync(data), [registeredUser]);
    
    const loadUniversities = useCallback(async (acronym: string) => await findUniversitiesByAcronym(acronym), [universities]);

    useEffect(() => { findCoursesAsync().then() }, []);

    return(

        <Formik enableReinitialize initialValues={ user } onSubmit={ handleSubmit } validationSchema={ schema }>
            
            <Form className="user-register-form">

                <MaskedInput mask={usernameMask} placeholder="Digite o seu username..." type="text" name="userName" label="Nome de usuário:"/>
                <Input placeholder="Digite o seu nome completo.." type="text" name="fullName" label="Nome completo:"/>
                <Input placeholder="Digite o seu endereço de e-mail..." type="email" name="email" label="Email:"/>
                
                <div className="passwords">
                    <Input placeholder="Digite a sua senha..." type="password" name="password" label="Senha:"/>
                    <Input placeholder="Confirme a sua senha..." type="password" 
                        name="confirmPassword" label="Confirmação de senha" />
                </div>

                <div className="academics">

                    <Select 
                        data={ courses }
                        mapDataToSelect={ mapCoursesToSelect } 
                        name="courseId" 
                        label="Curso" 
                        placeholder="Selecione o seu curso"
                    />
                    
                    <AsyncSelect 
                        data = { universities }
                        name="university"  
                        label="Universidade" 
                        loadAsync={ loadUniversities }
                        mapDataToSelect = { mapUniversitiesToSelect }
                        placeholder="Pesquise pela sua universidade (por sigla)"
                    />

                </div>

                <Checkbox label="Li e aceito os termos de condições de uso" name="termsAccepted"/>

                <Button className="submit-button" type="submit">Enviar</Button>

            </Form>

        </Formik>
        
    )
}

const mapStateToProps = (state:AppState): IStateProps => ({
    registeredUser: state.users.data,
    universities: state.universities.data,
    courses: state.courses.data
});

const mapDispatchToProps = (dispatch:AppDispatch): IDispatchProps => ({
    signUpAsync: (user:IUserRegister) => dispatch(signUpAsync(user)),
    findUniversitiesByAcronym: (acronym: string) => dispatch(findByAcronymAsync(acronym)),
    findCoursesAsync: () => dispatch(findCoursesAsync())
});

export default connect(mapStateToProps, mapDispatchToProps)(UserRegisterForm);