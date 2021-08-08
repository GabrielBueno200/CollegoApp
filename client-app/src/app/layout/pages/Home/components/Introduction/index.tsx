import React from 'react';

/* Hooks */
import useModal from '../../../../../hooks/useModal';

/* Components */
import SearchBar from '../../../../../common/SearchBar';
import Button from '../../../../../common/Buttons/Default';
import { default as RegisterForm } from '../../../../components/UserRegisterForm';
import { default as LoginForm } from '../../../../components/UserLoginForm';

/* Styles */
import './styles.scss';

const Introduction: React.FC = () => {

    const [ isRegistering, openRegisterModal, RegisterModal ] = useModal(["Cadastro de conta", RegisterForm]);
    const [ isAuthenticating, openLoginModal, LoginModal ] = useModal(["Entrar", LoginForm]);
  
    return( 
    
        <div className="introduction">
            
            <div className="buttons">
                <Button className="btn-light" onClick={openLoginModal}>Entrar</Button>
                <Button onClick={openRegisterModal}>Cadastrar</Button>
            </div>

            <div className="brand">
                <h1 className="subtitle">COLLEGO</h1>
                <h2 className="slogan">O SEU GRUPO DE ESTUDOS EM TODO LUGAR.</h2>
                <SearchBar/>
            </div>

            { isRegistering && <RegisterModal/> }

            { isAuthenticating && <LoginModal/> }

        </div>

    )
};

export default Introduction;