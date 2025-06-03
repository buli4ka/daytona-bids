import styles from './main-layout.module.css';
import { PropsWithChildren } from 'react';
const LayoutContainer = ({ children, testId = 'layout-container' }: PropsWithChildren<{ testId?: string }>) => {
  return (
    <div className={styles.container} data-testid={testId}>
      {children}
    </div>
  );
};

export default LayoutContainer;
