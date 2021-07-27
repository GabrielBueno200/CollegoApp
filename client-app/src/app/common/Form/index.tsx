import React from 'react';
import { Form as FormikForm, FormikFormProps } from 'formik';

/* Utils */
import './Validator'; 

/* Styles */
import './styles.scss'


const Form: React.FC<FormikFormProps> = props => {

    return <FormikForm {...props} 
                onKeyDown={e => e.code === "Enter" && e.preventDefault()} 
                className={`default-form ${props.className}`}/>
};


export default Form;