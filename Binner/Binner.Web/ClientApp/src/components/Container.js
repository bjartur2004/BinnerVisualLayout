import { divide } from "lodash";
import React, { useState, useMemo, useEffect, useLayoutEffect, useRef } from "react";
import { useTranslation } from 'react-i18next';

export const Container = (props) => {

    const [container, setContainer] = useState(null);
    const [scale, setScale] = useState(null);
    const [position, setPosition] = useState({ x: 0, y: 0 });
    const [size, setSize] = useState({ width: 200, height: 200 });
    const [isDragging, setIsDragging] = useState(false);
    const [isResizing, setIsResizing] = useState(false);

    const componentRef = useRef(null);

    const { t } = useTranslation();

    const handleMouseDownDrag = (e) => {
        e.stopPropagation();
        setIsDragging(true);
        componentRef.current = {
            startX: e.clientX - position.x,
            startY: e.clientY - position.y,
        };
    };

    const handleMouseDownResize = (e) => {
        setIsResizing(true);
        componentRef.current = {
            startX: e.clientX,
            startY: e.clientY,
            startWidth: size.width,
            startHeight: size.height,
        };
    };

    const handleMouseMove = (e) => {
        e.stopPropagation();
        if (isDragging) {
            setPosition({
                x: (e.clientX - componentRef.current.startX) * 1/scale,
                y: (e.clientY - componentRef.current.startY) * 1/scale,
            });
            console.log(position.x, e.clientX, componentRef.current.startX, e.clientX - componentRef.current.startX);

        }
        if (isResizing) {
            setSize({
                width: componentRef.current.startWidth + (e.clientX - componentRef.current.startX) * 1/scale,
                height: componentRef.current.startHeight + (e.clientY - componentRef.current.startY) * 1/scale,
            });
        }
    };

    const handleMouseUp = () => {
        setIsDragging(false);
        setIsResizing(false);
    };

    const renderContainer = useMemo(() => {
        //console.log(container);
        if (container) {

            return (
                // render populated container
                <div className="ContainerBody"
                    style={{
                        width: size.width,
                        height: size.height,
                        transform: `translate(${position.x}px, ${position.y}px)`,
                    }}
                    onMouseMove={handleMouseMove}
                    onMouseUp={handleMouseUp}
                    onMouseLeave={handleMouseUp}
                >
                    <div className="drag-bar" onMouseDown={handleMouseDownDrag}></div>
                    <div className="resize-handle" onMouseDown={handleMouseDownResize}></div>
                </div>
            );
        } else {
            return <p>undefined container</p>;
        }

    });

    useMemo(() => {
        setContainer(props.container);
    }, [props.container]);
    useMemo(() => {
        setScale(props.scale);
    }, [props.scale]);

    return (
        <>
            {renderContainer}
        </>
    );

};