import React from 'react';
import Button from '../../../../../common/Buttons/Default';
import useModal from '../../../../../hooks/useModal';
import SearchBar from '../../../../../common/SearchBar';
import { default as RegisterForm } from '../../../../components/UserRegisterForm';
import './styles.scss';

const Introduction: React.FC = () => {

    const [ isRegistering, openRegisterModal, RegisterModal ] = useModal(["Cadastro de conta"]);
  
    return( 
    
        <div className="introduction">
            
            <div className="buttons">
                <Button className="btn-light">Logar</Button>
                <Button onClick={() => openRegisterModal()}>Cadastrar</Button>
            </div>

            <div className="brand">
                <h1 className="subtitle">COLLEGO</h1>
                <h2 className="slogan">O SEU GRUPO DE ESTUDOS EM TODO LUGAR.</h2>
                <SearchBar/>
            </div>

            {isRegistering && ( 
                <RegisterModal>

                    <RegisterForm/>

                </RegisterModal>
            )}

        </div>

    )
};

export default Introduction;