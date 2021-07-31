import { IOption } from "../Options";

export default interface ISelectProps {
    label: string;
    name: string;
    className?: string;
    placeholder: string;
    value?: string;
    data: any[];
    mapDataToSelect: (data: any[]) => IOption[];
};