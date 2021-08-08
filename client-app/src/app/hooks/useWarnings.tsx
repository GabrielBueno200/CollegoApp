import React, { useState } from 'react';
import Warnings from '../common/Warnings';

type WarningHookReturn = [
    boolean,
    () => void,
    React.FC
];

type WarningHookParams = [
    any,
    boolean,
    boolean
];

const useWarnings = ( [ data, areErrors, isAlertWarning ] : WarningHookParams ) : WarningHookReturn  => {

    const [ hasWarnings, setHasWarnings ] = useState<boolean>(false);
    
    const openWarnings = () => setHasWarnings(true);

    const closeWarnings = () => setHasWarnings(false);

    const CustomWarnings: React.FC = ({ children }) => 
        hasWarnings ? 
            <Warnings 
                data={ data } 
                areErrors={ areErrors } 
                onClose={ closeWarnings } 
                isAlertWarning={ isAlertWarning }
            />
        : <></>

    return [hasWarnings, openWarnings, CustomWarnings];

}

export default useWarnings;