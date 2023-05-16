import AddSpecialty from "@/components/voters/AddSpecialty";
import AddVoter from "@/components/voters/AddVoter";
import AddYear from "@/components/voters/AddYear";
import Filters from "@/components/voters/Filters";
import VoterTable from "@/components/voters/VoterTable";
import React, { FunctionComponent } from "react";

const page = () => {
    return (
        <main className="px-20 py-32">
            <h1 className="text-2xl font-semibold">
                Mantenimiento de votantes
            </h1>
            <UserTable />
            <div className="grid grid-cols-1 lg:grid-cols-2 lg:gap-20 my-5">
                <AddYear />
                <AddSpecialty></AddSpecialty>
                <AddVoter></AddVoter>
            </div>
        </main>
    );
};

export default page;

const UserTable = () => (
    <div className="flex flex-col">
        <Filters></Filters>
        <VoterTable></VoterTable>
    </div>
);
