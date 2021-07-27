import React from 'react';
import { useField } from 'formik';
import './styles.scss';
import { IOption } from './Options';
import { default as ReactSelect } from 'react-select';

interface IProps {
  label: string;
  name: string;
  hasButton?: boolean;
  options?: IOption[];
  className?: string;
  placeholder: string;
  value?: string;
}

const Select: React.FC<IProps> = ({ label, children, ...props }) => {
  
  const [field, meta, helpers] = useField(props);

  return (
    <span className={`default-select`}>

      <label className="default-select-label">{ label }</label>
      
      <ReactSelect 
            className="default-select-field"
            name={ props.name }
            defaultValue={ props.value || undefined }
            value={ field.value || undefined }   
            onChange={ e => helpers.setValue(e.target.value) }
            placeholder={ props.placeholder } 
      >
            <option value="val1">Valor 1</option>     
            <option value="val2">Valor 2</option>   
          
      </ReactSelect> 

      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default Select;