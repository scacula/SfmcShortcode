using Newtonsoft.Json.Linq;
using RestSharp;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SfmcShortcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadShortcodes_Click(object sender, EventArgs e)

        {

            lstChange.Items.Clear();
            lstShortcodes.Items.Clear();

            string token = "";

            try
            {
                token = GetAuthToken(txtClientId.Text.Trim(), txtClientSecret.Text.Trim(), txtMid.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }

            this.Cursor = Cursors.WaitCursor;


            List<string> lista = GetDefinitionKeys(token, 1, chkActive.Checked, txtShortcode.Text.Trim());

            this.Cursor = Cursors.Default;

            foreach (string s in lista)
            {
                lstShortcodes.Items.Add(s);
            }


            lblTotal.Text = "Total " + lista.Count.ToString();


            MessageBox.Show(string.Format("Registros Carregados:{0}", lista.Count));
        }


        private static string GetAuthToken(string clientId, string clientSecret, string mid)
        {

            string token = string.Empty;

            var client = new RestClient();

            try
            {

                var authBody = "{\"grant_type\": \"client_credentials\",\"client_id\": \"" + clientId + "\",\"client_secret\": \"" + clientSecret + "\",\"account_id\": \"" + mid + "\"}";


                var authRequest = new RestRequest("https://mc6rnt1qcqf78nd3jvzt54rvp9l0.auth.marketingcloudapis.com/v2/token", Method.Post).AddStringBody(authBody, "application/json");
                authRequest.AddHeader("Content-Type", "application/json");
                authRequest.AddHeader("Authorization", "Bearer YVpmmZR6PYrDbHQY4MTCM2yy");
                var authResponse = client.ExecuteAsync(authRequest).Result.Content;
                var authjsonObject = JObject.Parse(authResponse);

                Console.WriteLine(authResponse.ToString());
                token = ((Newtonsoft.Json.Linq.JValue)authjsonObject.SelectToken("access_token")).Value.ToString();
                int expires_in = int.Parse(((Newtonsoft.Json.Linq.JValue)authjsonObject.SelectToken("expires_in")).Value.ToString());

                expires_in = expires_in - 10;

                //expiraTokenTransacional = DateTime.Now.AddSeconds(expires_in);


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Falha ao Autenticar na SFMC. {0}", ex.ToString()));
            }

            return token;

        }


        private List<string> GetDefinitionKeys(string accesstoken, int page, bool active, string shortcode)
        {

            var client = new RestClient();
            List<string> listDefinition = new List<string>();

            try
            {



                var request = new RestRequest("https://mc6rnt1qcqf78nd3jvzt54rvp9l0.rest.marketingcloudapis.com/messaging/v1/sms/definitions?$page=" + page.ToString() + "&$pagesize=100", Method.Get);
                request.AddHeader("Authorization", "Bearer " + accesstoken);
                request.AddHeader("Content-Type", "application/json");

                var response = client.ExecuteAsync(request).Result.Content;

                var authjsonObject = JObject.Parse(response);

                bool hasValues = false;

                foreach (var item in authjsonObject.Values())
                {


                    if (item.HasValues)
                    {
                        object strStatus = null;
                        object strDk = null;

                        hasValues = true;

                        foreach (var row in item)
                        {
                            var strName = row["name"];
                            if (strName != null)
                                strName = strName.ToString();

                            strStatus = row["status"];
                            if (strStatus != null)
                                strStatus = strStatus.ToString();


                            strDk = row["definitionKey"];
                            if (strDk != null)
                            {
                                strDk = strDk.ToString();
                            }


                            string shortNumber = "";
                            if (active)
                            {


                                if (strStatus.ToString() == "Active")
                                {

                                    shortNumber = GetShortcode(accesstoken, strDk.ToString());


                                    if ((shortNumber.Trim() == shortcode.Trim()) || (string.IsNullOrEmpty(shortcode)))
                                    {
                                        listDefinition.Add(strDk.ToString() + " # " + shortNumber); ;
                                    }

                                }
                            }
                            else
                            {
                                shortNumber = GetShortcode(accesstoken, strDk.ToString());

                                if ((shortNumber.Trim() == shortcode.Trim()) || (string.IsNullOrEmpty(shortcode)))
                                {
                                    listDefinition.Add(strDk.ToString() + " # " + shortNumber); ;
                                }


                            }

                        }

                    }


                }

                if (hasValues)
                    listDefinition.AddRange(GetDefinitionKeys(accesstoken, page + 1, active, shortcode));


            }
            catch (Exception ex)
            {

                return listDefinition;
            }

            return listDefinition;



        }


        private string GetShortcode(string accesstoken, string definitionKey)
        {

            var client = new RestClient();
            string shortcode = "";

            try
            {



                var request = new RestRequest("https://mc6rnt1qcqf78nd3jvzt54rvp9l0.rest.marketingcloudapis.com/messaging/v1/sms/definitions/" + definitionKey.ToString().Trim(), Method.Get);
                request.AddHeader("Authorization", "Bearer " + accesstoken);
                request.AddHeader("Content-Type", "application/json");

                var response = client.ExecuteAsync(request).Result.Content;

                var authjsonObject = JObject.Parse(response);

                bool hasValues = false;

                if (authjsonObject.HasValues)
                {



                    var authsubscription = JObject.Parse(authjsonObject["subscriptions"].ToString());

                    shortcode = authsubscription["shortCode"].ToString();

                }



            }
            catch (Exception ex)
            {

                return shortcode;
            }

            return shortcode;



        }



        private bool ChangeShortcode(string accesstoken, string item, string newshortcode)
        {

            var client = new RestClient();
            string definitionKey = item.Split('#')[0].Trim();

            try
            {



                var request = new RestRequest("https://mc6rnt1qcqf78nd3jvzt54rvp9l0.rest.marketingcloudapis.com/messaging/v1/sms/definitions/" + definitionKey.Trim(), Method.Patch);
                request.AddHeader("Authorization", "Bearer " + accesstoken);
                request.AddHeader("Content-Type", "application/json");

                request.AddJsonBody("{\"subscriptions\":{\"shortCode\":\"" + newshortcode + "\",\"countryCode\":\"BR\"}}");

                var response = client.ExecuteAsync(request).Result.StatusCode;

                if (response == System.Net.HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;



        }


        private bool DisableDefinitionKey(string accesstoken, string item)
        {

            var client = new RestClient();
            string definitionKey = item.Split('#')[0].Trim();

            try
            {



                var request = new RestRequest("https://mc6rnt1qcqf78nd3jvzt54rvp9l0.rest.marketingcloudapis.com/messaging/v1/sms/definitions/" + definitionKey.Trim(), Method.Delete);
                request.AddHeader("Authorization", "Bearer " + accesstoken);
                request.AddHeader("Content-Type", "application/json");

                var response = client.ExecuteAsync(request).Result.StatusCode;

                if (response == System.Net.HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }

            return true;



        }



        private void lstShortcodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstChange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstChange_DoubleClick(object sender, EventArgs e)
        {
            if (lstChange.SelectedItem != null)
            {

                lstChange.Items.Remove(lstChange.SelectedItem);
            }

        }

        private void lstShortcodes_DoubleClick(object sender, EventArgs e)
        {
            if (lstShortcodes.SelectedItem != null)
            {
                lstChange.Items.Add(lstShortcodes.SelectedItem.ToString());

                lstShortcodes.Items.Remove(lstShortcodes.SelectedItem);
            }
        }

        private void btnChangeShortcode_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNewShortcode.Text))
            {
                return;
            }


            string token = "";

            try
            {
                token = GetAuthToken(txtClientId.Text.Trim(), txtClientSecret.Text.Trim(), txtMid.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return;
            }

            int count = 0;
            foreach (var item in lstChange.Items)
            {
                bool sucesso = ChangeShortcode(token, item.ToString(), txtNewShortcode.Text.ToString());
                if (sucesso)
                    count++;
            }

            MessageBox.Show(string.Format("Registros Atualizados:{0} , Falha ao Atualizar: {1}", count, lstChange.Items.Count - count));

        }

        private void btnDisableDk_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem ceteza que deseja desabilitar as DefinitionKeys?", "Desabilitar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                string token = "";

                try
                {
                    token = GetAuthToken(txtClientId.Text.Trim(), txtClientSecret.Text.Trim(), txtMid.Text.Trim());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    return;
                }

                int count = 0;
                foreach (var item in lstChange.Items)
                {
                    bool sucesso = DisableDefinitionKey(token, item.ToString());
                    if (sucesso)
                        count++;
                }

                MessageBox.Show(string.Format("Registros Desabilitados:{0} , Falha ao Atualizar: {1}", count, lstChange.Items.Count - count));

            }
        }
    }
}