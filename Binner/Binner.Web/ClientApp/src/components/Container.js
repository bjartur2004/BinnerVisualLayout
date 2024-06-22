import React, { useState, useMemo, useEffect, useLayoutEffect } from "react";
import { useTranslation } from 'react-i18next';

export const Container = (props) => {

    const [container, setContainer] = useState();
    const [containerInnitComplete, setContainerInnitComplete] = useState(props.partInnitComplete);


    const { t } = useTranslation();

    const renderContainer = useMemo(() => {
        if (containerInnitComplete === true || container) {
            console.log(props);

            return (
                // render populated container
                <p>{container.label}</p>
            );
        } else {
            if (containerInnitComplete === true && !container) {console.error("container property undefined");}

            // render unpopulated container
            return <p>part</p>;
        }

    });

    useEffect(() => {
        setContainer(props.container);
    }, [props.container]);


    return (
        <>
            {renderContainer}
        </>
    );

};