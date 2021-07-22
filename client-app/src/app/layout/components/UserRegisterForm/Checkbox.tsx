import React from 'react';
import { useField, Form, FormikProps, Formik } from 'formik';

interface IProps {
  label: string;
  name: string;
}


const Input: React.FC<IProps> = ({ label, ...props }) => {
  
  const [field, meta] = useField(props);

  return (
    <>

      <input type="checkbox" {...field} {...props} />
        {label}
    
      {meta.touched && meta.error && (
        <div className="error">{meta.error}</div>
      )}
      
    </>
  );
};

export default Input;