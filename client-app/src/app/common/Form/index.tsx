import React from 'react';
import { Form as FormikForm, FormikFormProps } from 'formik';

/* Utils */
import './Validator'; 

/* Styles */
import './styles.scss'


const Form: React.FC<FormikFormProps> = props => {

    return <FormikForm {...props} className={`default-form ${props.className}`}/>
};


export default Form;