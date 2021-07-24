import React, { ButtonHTMLAttributes } from 'react';
import './styles.scss';

const Button: React.FC<ButtonHTMLAttributes<HTMLButtonElement>> = ({ children, ...props }) => {

    const { onClick, className: customClasses, type } = props;

    return (
        <button 
            className={`default-button ${customClasses}`}
            type={type} 
            onClick={onClick}>
            { children }            
        </button>
    );
}

export default Button;