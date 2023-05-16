import axios from "axios";

const GetAllSpecialties = () => {
    return axios
        .get<SpecialtyModel[]>("http://localhost:5251/api/v1/specialties")
        .then((res) => res.data)
        .catch((err) => err.message);
};

export default GetAllSpecialties;
