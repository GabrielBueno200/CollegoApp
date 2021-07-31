/* Modules */
import React from 'react';

/* Hooks */
import { useField } from 'formik';

/* Models */
import IInputProps from './models/props';

/* Styles */
import './styles.scss';

const Input: React.FC<IInputProps> = ({ label, symbol, ...props }) => {
  
  const [field, meta] = useField(props);

  return (
    <span className={`default-input`}>

      <label className="default-input-label">{ label }:</label>

      <div className="default-input-field">
        { !!symbol && <span className="default-input-symbol">{ symbol }</span> }
        <input autoComplete="off" {...field} {...props} />
      </div>
        
      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default Input;