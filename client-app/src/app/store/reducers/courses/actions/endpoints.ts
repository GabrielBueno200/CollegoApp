import { default as api } from '../../../../api';
import { ICourse } from '../../../../models/courses/course';

export enum Endpoints {
    findAll = "Course/find",
}

interface ICourseRequester {
    findAll: () => Promise<ICourse[]>;
};

const ApiRequest : ICourseRequester = {
    findAll: () => api.get<ICourse[]>(Endpoints.findAll)
};

export default ApiRequest;
