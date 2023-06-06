import React from 'react';
import { Button } from '@mui/material';
import { GetDupa } from '../../services/sampleService';

export const SamplePage = () => {
  return (
    <div>
      <Button onClick={GetDupa} style={{ backgroundColor: 'Green', width: '200px' }}>
        SamplePage
      </Button>
    </div>
  );
};
