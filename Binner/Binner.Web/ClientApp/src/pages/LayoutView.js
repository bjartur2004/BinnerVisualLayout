import React, { useCallback, useRef, useState, useMemo, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Segment } from "semantic-ui-react";
import { useTranslation } from "react-i18next";
import debounce from "lodash.debounce";
import QuickPinchZoom, { make3dTransformValue } from "react-quick-pinch-zoom";
import { fetchApi } from "../common/fetchApi";

import { Container } from "../components/Container.js";

import "./LayoutView.css";
import { partial } from "lodash";

export function LayoutView(props) {
    const { t } = useTranslation();
    const navigate = useNavigate();
    const DebounceTimeMs = 400;
    const abortController = useRef(new AbortController());

    const [containers, setContainers] = useState([]);
    const [containerInitComplete, setContainerInitComplete] = useState(false);

    const layoutCanvas = useRef();

    const onUpdate = useCallback(({ x, y, scale }) => {
        const { current: canvas } = layoutCanvas;
        if (canvas) {
            const value = make3dTransformValue({ x, y, scale });
            canvas.style.setProperty("transform", value);
        }
    }, []);

    const loadParts = useCallback(async () => {
        /*const response = await fetchApi(
            `api/container/0`
        );*/

        const request = {
            Label:"uwu"
        };


        const response = await fetchApi(`api/container`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(request)
        });

        //const { data } = response;
        //const pageOfData = data.items;
        //setContainers(pageOfData);
        console.log(response);
        setContainerInitComplete(true);
        return response;
    }, []);

    const loadPartsDebounced = useMemo(() => debounce(loadParts, DebounceTimeMs), [loadParts]);

    useEffect(() => {
        loadPartsDebounced();
        return () => {
            abortController.current.abort();
        };
    }, [loadPartsDebounced]);

    return (
        <div className="layoutView">
            <h1>{t('page.home.title', "Dashboard")}</h1>
            <p>{t('page.home.description', "Binner is an inventory management app for makers, hobbyists and professionals.")}</p>
            <Segment className="layoutViewPane">
                <QuickPinchZoom onUpdate={onUpdate} verticalPadding={1000} horizontalPadding={1000} maxZoom={10} minZoom={0.1} zoomOutFactor={0} wheelScaleFactor={300}>
                    <div className="layoutCanvas" ref={layoutCanvas} alt="canvas">
                        <Container part={containers[0]} partInnitComplete={containerInitComplete}/>
                    </div>
                </QuickPinchZoom>
            </Segment>
        </div>
    );
}
