import React from 'react';
import InputMask, { Props } from 'react-input-mask';
import { useField } from 'formik';
import '../styles.scss';

interface IProps {
  label: string;
  name: string;
  placeholder: string;
  type: string;
  mask: string | (string | RegExp)[];
}

const MaskedInput: React.FC<IProps> = ({ label, mask, ...props }) => {
  
  const [field, meta] = useField(props);

  return (
    <span className={`default-input`}>

      <label className="default-input-label">{ label }</label>
      <InputMask className="default-input-field" autoComplete="off" {...props} {...field}  
        mask={mask}  
      />

      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default MaskedInput;