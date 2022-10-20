import React, { PureComponent } from 'react';
import './_input.scss';

export default class Input extends PureComponent {
    
    constructor(props, type) {
        super(props);
        this._type = type;
    }

    onRef = (ref) => {
        this._ref = ref;
        
        if (ref && this.props.defaultValue)
            this.value = this.props.defaultValue;
        
        if (this.props.innerRef)
            this.props.innerRef(ref);
    };

    get value() {
        return this._ref.value;
    }
    
    set value(val) {
        this._ref.value = val;
    }

    get input() {
        if (!this._ref || !this._ref.input) return this._ref;
        return this._ref.input;
    }
    
    get customInput() {
        return this.props.customInput;
    }

    render() {
        const {
            type, defaultValue, className, flex, icone, title, onIconeClick,
            horizontal, innerRef, customInput, invisivel, inputClass, ...props
        } = this.props;

        let cl = className;
        let tooltip = 'tooltip-left';
        
        if (flex >= 0) {
            cl = (cl ? cl + ' ' : '') + 'flex-' + flex;
        }
        
        if (horizontal) {
            cl = (cl ? cl + ' ' : '') + 'horizontal';
            tooltip = 'tooltip-right';
        }
        
        if (invisivel) {
            cl = (cl ? cl + ' ' : '') + 'invisivel';
        }
        
        return (
            <label className={cl}>
                {this.props.label &&
                    <span aria-label={title} className={tooltip}>
                        {this.props.label}
                        {icone && <em className="icone" onClick={onIconeClick}>{icone}</em>}
                    </span>
                }
                {this.renderInputBox({className: inputClass, ...props})}
            </label>
        );
    }
    
    renderInputBox(props) {
        const {
            prefixo, sufixo,
            prefixoClass, sufixoClass,
            onPrefixoClick, onSufixoClick,
            ...inputProps
        } = props;
        
        if(!prefixo && !sufixo) {
            return this.renderInput(inputProps);
        }
        
        let className = 'input-afixo';
        if(prefixo) className += ' prefixo';
        if(sufixo) className += ' sufixo';
        
        return (
            <div className={className}>
                {prefixo && <span className={prefixoClass} onClick={onPrefixoClick}>{prefixo}</span>}
                {this.renderInput(inputProps)}
                {sufixo && <span className={sufixoClass} onClick={onSufixoClick}>{sufixo}</span>}
            </div>
        )
    }
    
    renderInput(props) {
        const inputProps = {type: this._type, ref: this.onRef, autoComplete: 'off', ...props};
        const CustomInput = this.customInput;
        
        if (CustomInput)
            return <CustomInput {...inputProps} />;
        else
            return <input {...inputProps} />;
    }

}