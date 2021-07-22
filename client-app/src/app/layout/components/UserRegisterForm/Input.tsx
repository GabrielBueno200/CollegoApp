import React from 'react';
import { useField, Form, FormikProps, Formik } from 'formik';

interface IProps {
  label: string;
  name: string;
  type: string;
  placeholder?: string;
  value?: string;
}

const Input: React.FC<IProps> = ({ label, ...props }) => {
  
  const [field, meta] = useField(props);

  return (
    <>
      <label>{label}</label>
      <input {...field} {...props} />

      {meta.touched && meta.error && (
        <div className="error">{meta.error}</div>
      )}
    </>
  );
};

export default Input;