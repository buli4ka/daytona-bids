'use client';
import React from 'react';
import { usePathname, useSearchParams, useRouter } from 'next/navigation';

const VehicleFilter = () => {
  const [query, setQuery] = React.useState('');
  const router = useRouter();
  const searchParams = useSearchParams();
  const pathname = usePathname();

  console.log(searchParams.get('query'));

  const onQueryChange = () => {
    const current = new URLSearchParams(Array.from(searchParams.entries()));
    console.log(current);
    current.set('query23', query);

    const search = current.toString();
    // or const query = `${'?'.repeat(search.length && 1)}${search}`;
    const params = search ? `?${search}` : '';
    router.push(`${pathname}${params}`);
  };

  return (
    <div>
      <input value={query} onChange={e => setQuery(e.target.value)} />
      <button onClick={onQueryChange}>add</button>
    </div>
  );
};

export default VehicleFilter;
