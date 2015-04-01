package com.crittercism.fragments;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;


import com.crittercism.MainActivity;
import com.crittercism.R;
import com.crittercism.app.Crittercism;

public class TransactionFragment extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.fragment_transaction, container, false);


        ListView listView = (ListView) v.findViewById(R.id.transactionsListView);
        final String labels[] = { "Login", "Browse", "Reserve", "Confirm" };

        ArrayAdapter arrayAdapter = new ArrayAdapter<String>(
                getActivity(),
                R.layout.transaction_buttons,
                R.id.transactionName,
                labels)
        {
            @Override
            public View getView(int position, View convertView, ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                String txnName = labels[position];

                Button begin = (Button) view.findViewById(R.id.beginButton);
                begin.setOnClickListener(new BeginTransactionButtonAction(txnName));

                Button end = (Button) view.findViewById(R.id.endButton);
                end.setOnClickListener(new EndTransactionButtonAction(txnName));

                Button fail = (Button) view.findViewById(R.id.failButton);
                fail.setOnClickListener(new FailTransactionButtonAction(txnName));

                Button increment = (Button) view.findViewById(R.id.valueIncrementButton);
                increment.setOnClickListener(new IncrementTransactionButtonAction(txnName));

                return view;
            }
        };

        listView.setAdapter(arrayAdapter);

        return v;
    }

    private static class BeginTransactionButtonAction extends TransactionButtonAction {

        private BeginTransactionButtonAction(String transactionName) {
            super(transactionName);
        }

        @Override
        public void onClick(View v) {
            Crittercism.beginTransaction(this.transactionName);
        }
    }

    private static class EndTransactionButtonAction extends TransactionButtonAction {

        private EndTransactionButtonAction(String transactionName) {
            super(transactionName);
        }

        @Override
        public void onClick(View v) {
            Crittercism.endTransaction(this.transactionName);
        }
    }

    private static class FailTransactionButtonAction extends TransactionButtonAction {

        private FailTransactionButtonAction(String transactionName) {
            super(transactionName);
        }

        @Override
        public void onClick(View v) {
            Crittercism.failTransaction(this.transactionName);
        }
    }

    private static class IncrementTransactionButtonAction extends TransactionButtonAction {

        private IncrementTransactionButtonAction(String transactionName) {
            super(transactionName);
        }

        @Override
        public void onClick(View v) {
            int value = Crittercism.getTransactionValue(this.transactionName);
            if (value == -1) {
                // The value wasn't set
                value = 1;
            }

            Crittercism.setTransactionValue(this.transactionName, value + 1);
        }
    }

    private static abstract class TransactionButtonAction implements View.OnClickListener {
        protected String transactionName;

        private TransactionButtonAction(String transactionName) {
            this.transactionName = transactionName;
        }
    }

}
