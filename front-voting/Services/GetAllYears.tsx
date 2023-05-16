import axios from "axios";

const GetAllYears = () => {
    return axios
        .get<YearModel[]>("http://localhost:5251/api/v1/years")
        .then((res) => res.data)
        .catch((err) => err.message);
};

export default GetAllYears;
