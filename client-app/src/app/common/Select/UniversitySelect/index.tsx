import React, { useState, useCallback } from 'react';
import { useField } from 'formik';
import { IOption } from '../Options';
import { IUniversity } from '../../../models/universities/university';
import Select from 'react-select';

interface IProps {
  label: string;
  name: string;
  options?: IOption[];
  className?: string;
  placeholder: string;
  value?: string;
  asyncFunction: (valueToSearch: string) => Promise<void>;
  mapDataToSelect: (data: IUniversity[]) => IOption[];
  data: IUniversity[];
};


const UniversitySelect: React.FC<IProps> = 
  ({ 
    label, 
    asyncFunction,
    data,
    mapDataToSelect,
    ...props 
  }) => {
  
  const [ field, meta, helpers ] = useField(props);

  const [ valueToSearch, setValueToSearch ] = useState<string>('');

  const searchValues = async () => await asyncFunction(valueToSearch);

  return (
    <span className={`default-select`}>

      <label className="default-select-label">{ label }</label>
      <Select
          className="default-select-field"
          name={ props.name }
          placeholder={ props.placeholder } 
          options={ mapDataToSelect(data) }
          onChange={ x => helpers.setValue(x!.value) }
          onInputChange={ e => setValueToSearch(e) }
          onKeyDown={ e => e.key === 'Enter' && searchValues() }
      />

      <small>Tecle enter para pesquisar</small>

      {meta.touched && meta.error && (
        <div className="form-field-error">{meta.error}</div>
      )}

    </span>
  );
};

export default UniversitySelect;