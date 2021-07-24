import React from 'react';
import { useField } from 'formik';
import './styles.scss';

interface IProps {
  label: string;
  name: string;
}


const Input: React.FC<IProps> = ({ label, ...props }) => {
  
  const [field, meta] = useField(props);

  return (

    <span className="default-checkbox">

      <input type="checkbox" className="default-checkbox-box" {...field} {...props} />
        {label}
    
      {meta.touched && meta.error && (
        <div className="error">{meta.error}</div>
      )}
      
    </span>

  );
};

export default Input;