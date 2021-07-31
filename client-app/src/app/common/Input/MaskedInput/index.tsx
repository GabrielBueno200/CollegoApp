import React from 'react';
import InputMask, { Props } from 'react-input-mask';
import { useField } from 'formik';
import '../styles.scss';
import IInputProps from '../models/props';

interface IProps extends IInputProps {
  format?: (attr: string) => string;
  mask?: string | (string | RegExp)[];
};

const MaskedInput: React.FC<IProps> = ({ label, mask = [], symbol, format, ...props }) => {
  
  const [field, meta, helpers] = useField(props);

  const applyFormat = (value: string) => !!format ? helpers.setValue(format(value)) : helpers.setValue(value);

  return (
    <span className={`default-input`}>

      <label className="default-input-label">{ label }:</label>

      <div className="default-input-field">

        { !!symbol && <span className="default-input-symbol">{ symbol }</span> }

        <InputMask autoComplete="off" {...props} {...field}  
            mask={ mask } 
            onChange={ e => applyFormat(e.target.value) } 
        />
        
      </div>

      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default MaskedInput;