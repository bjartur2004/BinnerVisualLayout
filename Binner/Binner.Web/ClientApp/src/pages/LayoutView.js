import React, { useCallback, useRef, useState, useMemo, useEffect, Component } from "react";
import { useNavigate } from "react-router-dom";
import { Segment } from "semantic-ui-react";
import { useTranslation } from "react-i18next";
import debounce from "lodash.debounce";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import { fetchApi } from "../common/fetchApi";

import { Container } from "../components/Container.js";

import "./LayoutView.css";

export function LayoutView(props) {
    const INNITIAL_ZOOM = 1;

    const { t } = useTranslation();
    const navigate = useNavigate();
    const DebounceTimeMs = 400;
    const abortController = useRef(new AbortController());

    const [containers, setContainers] = useState([]);
    const [containerInitComplete, setContainerInitComplete] = useState(false);
    const [zoomKey, setZoomKey] = useState(0);
    const [currentZoomScale, setCurrentZoomScale] = useState(INNITIAL_ZOOM);

    const layoutCanvas = useRef();

    const loadContainers = useCallback(async () => {
        const response = await fetchApi(
            `api/container/all`
        );

        // Example data
        setContainers([
            {
                containerId: 1,
                dateCreatedUtc: "2024-06-24T18:33:10.2026557Z",
                label: "uwu",
                parentContainerId: null,
                userId: 1,
                internalGridX: 12,
                internalGridY: 8,
                positionX: 0,
                positionY: 0,
                spanX: 10,
                spanY: 8
            },
            {
                containerId: 3,
                dateCreatedUtc: "2024-06-24T18:33:10.2026557Z",
                label: "uwu2",
                parentContainerId: null,
                userId: 1,
                internalGridX: 10,
                internalGridY: 12,
                positionX: 20,
                positionY: 5,
                spanX: 10,
                spanY: 12
            },
        ]);
        setContainerInitComplete(true);
        setZoomKey(prevKey => prevKey + 1); // Update the key to force re-render
        return response;
    }, []);

    const loadContainersDebounced = useMemo(() => debounce(loadContainers, DebounceTimeMs), [loadContainers]);

    useEffect(() => {
        loadContainersDebounced();
        return () => {
            abortController.current.abort();
        };
    }, [loadContainersDebounced]);

    const renderContainers = () => {
        return containers.map(container => <Container container={container} key={container.containerId} scale={currentZoomScale} />);
    }

    const updateZoomStateValues = (e) => {
        setCurrentZoomScale(e.state.scale);
    }

    return (
        <div className="layoutView">
            <h1>{t('page.home.title', "Dashboard")}</h1>
            <p>{t('page.home.description', "Binner is an inventory management app for makers, hobbyists and professionals.")}</p>
            <Segment className="layoutViewPane">
                <TransformWrapper
                    initialScale={INNITIAL_ZOOM}
                    minScale={0.25}
                    initialPositionX={-250}
                    initialPositionY={-400}
                    onZoom={(e) => updateZoomStateValues(e)}
            >
                <TransformComponent>
                    <div className="layoutCanvas" ref={layoutCanvas} alt="canvas">
                        {renderContainers()}
                    </div>
                </TransformComponent>
            
            </TransformWrapper>
            </Segment>
        </div>
    );
}