/* Models */
import React from 'react';
import { default as ReactSelect } from 'react-select';

/* Hooks */
import { useField } from 'formik';

/* Models */
import ISelectProps from './models/props';

/* Styles*/
import { styles } from './models/styles';
import './styles.scss';

const Select: React.FC<ISelectProps> = ({ label, data, mapDataToSelect, children, ...props }) => {
  
  const [field, meta, helpers] = useField(props);

  return (
    <span className={`default-select`}>

      <label className="default-select-label">{ label }:</label>
      
      <ReactSelect styles={ styles }
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