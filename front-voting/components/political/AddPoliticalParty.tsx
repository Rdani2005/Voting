"use client";

import axios from "axios";
import React, { useState } from "react";

type ImageFile = File & { preview: string };

type CreatePartyModel = {
    Name: string;
    PetUrl: string;
    ImageUrl: string;
};

interface Props {
    httpService: HttpService;
}

interface HttpService {
    post(url: string, data: any, config?: any): Promise<any>;
}

export class AxiosHttpService implements HttpService {
    async post(url: string, data: any, config?: any): Promise<any> {
        return axios.post(url, data, config);
    }
}

const AddPoliticalParty: React.FC<Props> = ({ httpService }) => {
    const [selectedFlagFile, setSelectedFlagFile] = useState<File | null>(null);
    const [selectedPetFile, setSelectedPetFile] = useState<File | null>(null);

    const [petUrl, setPetUrl] = useState<string>("");
    const [flagUrl, setFlagUrl] = useState<string>("");

    const [name, setName] = useState<string>("");

    const handleFileChange1 = (event: React.ChangeEvent<HTMLInputElement>) => {
        const files = event.target.files;
        if (files) {
            setSelectedFlagFile(files[0]);
        }
    };

    const handleFileChange2 = (event: React.ChangeEvent<HTMLInputElement>) => {
        const files = event.target.files;
        if (files) {
            setSelectedPetFile(files[0]);
        }
    };

    const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const uploadImages = async (flagFile: File, petFile: File) => {
        const flagForm = new FormData();
        flagForm.append("file", flagFile);
        flagForm.append("upload_preset", "votes_upload_images");

        const petForm = new FormData();
        petForm.append("file", petFile);
        petForm.append("upload_preset", "votes_upload_images");

        try {
            const flagResponse = await httpService.post(
                "https://api.cloudinary.com/v1_1/dthripqjz/image/upload",
                flagForm
            );
            const petResponse = await httpService.post(
                "https://api.cloudinary.com/v1_1/dthripqjz/image/upload",
                petForm
            );

            const flagUrl = flagResponse.data.secure_url;
            const petUrl = petResponse.data.secure_url;

            setFlagUrl(flagUrl);
            setPetUrl(petUrl);

            return { flagUrl, petUrl };
        } catch (error) {
            console.error(error);
            return null;
        }
    };
    const sendImageUrls = async (createPolitical: CreatePartyModel) => {
        const config = {
            headers: { "Content-Type": "application/json" },
        };

        try {
            const response = await httpService.post(
                "http://localhost:5251/api/v1/partidos/",
                createPolitical,
                config
            );
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    const handleUploadClick = async () => {
        if (!selectedFlagFile || !selectedPetFile) {
            console.error("Please select two image files");
            return;
        }

        await uploadImages(selectedFlagFile, selectedPetFile);

        if (flagUrl && petUrl) {
            sendImageUrls({ ImageUrl: flagUrl, PetUrl: petUrl, Name: name });
        }
    };

    return (
        <div>
            <input type="file" onChange={handleFileChange1} />
            <input type="file" onChange={handleFileChange2} />
            <input
                type="text"
                placeholder="Enter name"
                value={name}
                onChange={handleNameChange}
            />
            <button onClick={handleUploadClick}>Upload Images</button>
        </div>
    );
};

export default AddPoliticalParty;
