import React from 'react';
import { useField } from 'formik';
import './styles.scss';

interface IProps {
  label: string;
  name: string;
  type: string;
  className?: string;
  placeholder?: string;
  value?: string;
}

const Input: React.FC<IProps> = ({ label, ...props }) => {
  
  const [field, meta] = useField(props);

  return (
    <span className={`default-input`}>

      <label className="default-input-label">{ label }</label>
      <input className="default-input-field" autoComplete="off" {...field} {...props} />

      {meta.touched && meta.error && (
        <div className="error">{meta.error}</div>
      )}

    </span>
  );
};

export default Input;