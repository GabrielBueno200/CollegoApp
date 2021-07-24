import React from 'react';
import { Form as FormikForm, FormikFormProps } from 'formik';
import './styles.scss'

const Form: React.FC<FormikFormProps> = props => 
    <FormikForm {...props} className={`default-form ${props.className}`}/>

export default Form;
