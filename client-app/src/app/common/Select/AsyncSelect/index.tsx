/* Modules */
import React, { useState, useCallback } from 'react';
import Select from 'react-select';

/* Hooks */
import { useField } from 'formik';

/* Models */
import { IOption } from '../Options';
import ISelectProps from '../models/props';

/* Styles */
import { styles } from '../models/styles';

interface IProps extends ISelectProps {
  loadAsync: (valueToSearch: string) => Promise<void>;
  isLoading: boolean;
};

const AsyncSelect: React.FC<IProps> = 
  ({ 
    label, 
    data,
    loadAsync,
    isLoading,
    mapDataToSelect,
    ...props 
  }) => {
  
  const [ field, meta, helpers ] = useField(props);

  const [ valueToSearch, setValueToSearch ] = useState<string>('');

  const searchValues = async () => await loadAsync(valueToSearch);

  const loadingOption : IOption[] = [{ value: 0, label: "Procurando pela sua universidade..." }];



  return (
    <span className={`default-select`}>

      <label className="default-select-label">{ label }:</label>
      <Select styles={ styles }
          className="default-select-field"
          name={ props.name }
          placeholder={ props.placeholder } 
          options={ !isLoading ? mapDataToSelect(data) : loadingOption }
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

export default AsyncSelect;