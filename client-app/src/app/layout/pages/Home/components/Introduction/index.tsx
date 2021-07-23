import React from 'react';
import SearchBar from '../../../../../common/SearchBar';
import './styles.scss';

const Introduction: React.FC = () => {
  
    return( 
    
        <div className="introduction">
            
            <div className="brand">
                <h1 className="subtitle">COLLEGO</h1>
                <h2 className="slogan">O SEU GRUPO DE ESTUDOS EM TODO LUGAR.</h2>
                <SearchBar/>
            </div>


        </div>

    )
};

export default Introduction;