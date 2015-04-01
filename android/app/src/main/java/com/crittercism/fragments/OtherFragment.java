package com.crittercism.fragments;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import com.crittercism.R;
import com.crittercism.app.Crittercism;

import org.json.JSONException;
import org.json.JSONObject;

public class OtherFragment extends Fragment {

    private View v;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        this.v = inflater.inflate(R.layout.fragment_other, container, false);

        setButtonAction(v, R.id.usernameBobButton, new UserNameButtonAction("Bob"));
        setButtonAction(v, R.id.usernameSueButton, new UserNameButtonAction("Sue"));
        setButtonAction(v, R.id.usernameJoeButton, new UserNameButtonAction("Joe"));

        setButtonAction(v, R.id.level1Button, new MetadataButtonAction("Game Level", "Level 1"));
        setButtonAction(v, R.id.level5Button, new MetadataButtonAction("Game Level", "Level 5"));
        setButtonAction(v, R.id.level7Button, new MetadataButtonAction("Game Level", "Level 7"));

        setButtonAction(v, R.id.breadcrumbAbcButton, new BreadcrumbButtonAction("abc"));
        setButtonAction(v, R.id.breadcrumbXyzButton, new BreadcrumbButtonAction("xyz"));
        setButtonAction(v, R.id.breadcrumbHelloButton, new BreadcrumbButtonAction("hello"));

        setButtonAction(v, R.id.optInButton, new OptOutButtonAction(false));
        setButtonAction(v, R.id.optOutButton, new OptOutButtonAction(true));

        updateOptOutStatusLabel();

        return v;
    }

    private void setButtonAction(View v, int id, View.OnClickListener listener) {
        Button button = (Button) v.findViewById(id);
        button.setOnClickListener(listener);
    }

    private void updateOptOutStatusLabel() {
        TextView textView = (TextView)this.v.findViewById(R.id.statusText);
        boolean currentStatus = Crittercism.getOptOutStatus();
        textView.setText("OPT-OUT STATUS: " + currentStatus);
    }

    private class UserNameButtonAction implements View.OnClickListener {

        private String username;

        private UserNameButtonAction(String username) {
            this.username = username;
        }

        @Override
        public void onClick(View v) {
            Crittercism.setUsername(this.username);
        }
    }

    private class MetadataButtonAction implements View.OnClickListener {
        private String key;
        private String value;

        private MetadataButtonAction(String key, String value) {
            this.key = key;
            this.value = value;
        }

        @Override
        public void onClick(View v) {
            JSONObject json = new JSONObject();

            try {
                json.putOpt(key, value);
            } catch (JSONException e) {
                throw new AssertionError("Bad key/value: " + key + " " + value);
            }

            Crittercism.setMetadata(json);
        }
    }

    private class BreadcrumbButtonAction implements View.OnClickListener {

        private String breadrumb;

        private BreadcrumbButtonAction(String breadrumb) {
            this.breadrumb = breadrumb;
        }

        @Override
        public void onClick(View v) {
            Crittercism.leaveBreadcrumb(this.breadrumb);
        }
    }

    private class OptOutButtonAction implements View.OnClickListener {
        private boolean shouldOptOut;

        private OptOutButtonAction(boolean shouldOptOut) {
            this.shouldOptOut = shouldOptOut;
        }

        @Override
        public void onClick(View v) {
            Crittercism.setOptOutStatus(this.shouldOptOut);
            OtherFragment.this.updateOptOutStatusLabel();
        }
    }

}
