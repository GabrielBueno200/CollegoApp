import React from 'react';
import { useField } from 'formik';
import './styles.scss';
import { IOption } from './Options';
import { default as ReactSelect } from 'react-select';

interface IProps {
  label: string;
  name: string;
  hasButton?: boolean;
  className?: string;
  placeholder: string;
  value?: string;
  data: any;
  mapDataToSelect: (data: any[]) => IOption[];
}

const Select: React.FC<IProps> = ({ label, data, mapDataToSelect, children, ...props }) => {
  
  const [field, meta, helpers] = useField(props);

  return (
    <span className={`default-select`}>

      <label className="default-select-label">{ label }</label>
      
      <ReactSelect 
          className="default-select-field"
          name={ props.name }
          options={ mapDataToSelect(data) }
          onChange={ x => { helpers.setValue(x!.value) } }
          placeholder={ props.placeholder } 
      />

      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default Select;